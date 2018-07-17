using System;
using System.Collections.Generic;
using CoreGraphics;
using ADDC_MVVM;
using ADDC_MVVM.iOS;
using MapKit;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.iOS;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapRenderer))]
namespace ADDC_MVVM.iOS
{
	public class CustomMapRenderer : MapRenderer
	{
		UIView customPinView;
		List<CustomPin> customPins;

		protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.View> e)
		{
			base.OnElementChanged(e);

			if (e.OldElement != null)
			{
				var nativeMap = Control as MKMapView;
				nativeMap.GetViewForAnnotation = null;
				nativeMap.CalloutAccessoryControlTapped -= OnCalloutAccessoryControlTapped;
				nativeMap.DidSelectAnnotationView -= OnDidSelectAnnotationView;
				nativeMap.DidDeselectAnnotationView -= OnDidDeselectAnnotationView;
			}

			if (e.NewElement != null)
			{
				var formsMap = (CustomMap)e.NewElement;
				var nativeMap = Control as MKMapView;
				customPins = formsMap.CustomPins;

				nativeMap.GetViewForAnnotation = GetViewForAnnotation;
				nativeMap.CalloutAccessoryControlTapped += OnCalloutAccessoryControlTapped;
				nativeMap.DidSelectAnnotationView += OnDidSelectAnnotationView;
				nativeMap.DidDeselectAnnotationView += OnDidDeselectAnnotationView;
			}
		}

		MKAnnotationView GetViewForAnnotation(MKMapView mapView, IMKAnnotation annotation)
		{
			MKAnnotationView annotationView = null;
			try
			{
				if (annotation is MKUserLocation)
					return null;

				var anno = annotation as MKPointAnnotation;
				var customPin = GetCustomPin(anno);
				if (customPin == null)
				{
					throw new Exception("Custom pin not found");
				}

				annotationView = mapView.DequeueReusableAnnotation(customPin.branchId);

					annotationView = new CustomMKAnnotationView(annotation, customPin.branchId);
					if (customPin.Pin.Type == PinType.Place)
					{
						annotationView.Image = UIImage.FromFile("ic_branches.png");
					}
					if (customPin.Type.ToString() == customPin.branchId)
					{
						annotationView.Image = UIImage.FromFile("ic_branches.png");
					}
					else if (customPin.Type.ToString() == customPin.kioskId)
					{
						annotationView.Image = UIImage.FromFile("ic_kiosks.png");
					}
					else if (customPin.Type.ToString() == customPin.partnerId)
					{
						annotationView.Image = UIImage.FromFile("ic_partner.png");
					}



					annotationView.CalloutOffset = new CGPoint(0, 0);
					//annotationView.LeftCalloutAccessoryView = new UIImageView(UIImage.FromFile("monkey.png"));
					annotationView.RightCalloutAccessoryView = UIButton.FromType(UIButtonType.DetailDisclosure);
					//((CustomMKAnnotationView)annotationView).Id = customPin.Id;
					//((CustomMKAnnotationView)annotationView).Url = customPin.Url;

				annotationView.CanShowCallout = true;

			}
			catch (Exception ex)
			{

			}

			return annotationView;
		}

		void OnCalloutAccessoryControlTapped(object sender, MKMapViewAccessoryTappedEventArgs e)
		{
			var customView = e.View as CustomMKAnnotationView;
			if (!string.IsNullOrWhiteSpace(customView.Url))
			{
				UIApplication.SharedApplication.OpenUrl(new Foundation.NSUrl(customView.Url));
			}
		}

		void OnDidSelectAnnotationView(object sender, MKAnnotationViewEventArgs e)
		{
			var customView = e.View as CustomMKAnnotationView;
			customPinView = new UIView();


				customPinView.Frame = new CGRect(0, 0, 200, 84);
				//var image = new UIImageView(new CGRect(0, 0, 200, 84));
				//image.Image = UIImage.FromFile("xamarin.png");
				//customPinView.AddSubview(image);
				customPinView.Center = new CGPoint(0, -(e.View.Frame.Height + 75));
				e.View.AddSubview(customPinView);

		}

		void OnDidDeselectAnnotationView(object sender, MKAnnotationViewEventArgs e)
		{
			if (!e.View.Selected)
			{
				customPinView.RemoveFromSuperview();
				customPinView.Dispose();
				customPinView = null;
			}
		}

		CustomPin GetCustomPin(MKPointAnnotation annotation)
		{
			var position = new Position(annotation.Coordinate.Latitude, annotation.Coordinate.Longitude);
			foreach (var pin in customPins)
			{
				if (pin.Pin.Position == position)
				{
					return pin;
				}
			}
			return null;
		}
	}
}