using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace MeasureConvert
{
	[Activity(Label = "MeasureConvert", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		//int count = 1;
		private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
		{
			//Spinner spinner = (Spinner)sender;

			//string toast = string.Format("The planet is {0}", spinner.GetItemAtPosition(e.Position));
			//Toast.MakeText(this, toast, ToastLength.Long).Show();
		}


		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.Main);

			Spinner spinner = FindViewById<Spinner>(Resource.Id.MeasurementType);
			Spinner startunits = FindViewById<Spinner>(Resource.Id.StartUnits);
			Spinner targetunits = FindViewById<Spinner>(Resource.Id.TargetUnits);

			spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
			var adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.Measurements, Android.Resource.Layout.SimpleSpinnerItem);
			adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
			spinner.Adapter = adapter;

			Button enterbutton = FindViewById<Button>(Resource.Id.Enter);
			TextView selectstart = FindViewById<TextView>(Resource.Id.SelectStart);
			TextView title = FindViewById<TextView>(Resource.Id.Title);
			TextView selecttarget = FindViewById<TextView>(Resource.Id.SelectTarget);
			EditText input = FindViewById<EditText>(Resource.Id.Pounds);
			TextView output = FindViewById<TextView>(Resource.Id.Answer);
			Button convertbutton = FindViewById<Button>(Resource.Id.Convert);
			TextView enternumber = FindViewById<TextView>(Resource.Id.EnterNumber);
			Button resetbutton = FindViewById<Button>(Resource.Id.Reset);

			startunits.Visibility = ViewStates.Invisible;
			targetunits.Visibility = ViewStates.Invisible;
			selectstart.Visibility = ViewStates.Invisible;
			selecttarget.Visibility = ViewStates.Invisible;
			input.Visibility = ViewStates.Invisible;
			output.Visibility = ViewStates.Invisible;
			convertbutton.Visibility = ViewStates.Invisible;
			enternumber.Visibility = ViewStates.Invisible;
			resetbutton.Visibility = ViewStates.Gone;


			enterbutton.Click += (object sender, EventArgs e) =>
			{
				title.Visibility = ViewStates.Gone;
				startunits.Visibility = ViewStates.Visible;
				targetunits.Visibility = ViewStates.Visible;
				selectstart.Visibility = ViewStates.Visible;
				selecttarget.Visibility = ViewStates.Visible;
				input.Visibility = ViewStates.Visible;
				output.Visibility = ViewStates.Visible;
				convertbutton.Visibility = ViewStates.Visible;
				enternumber.Visibility = ViewStates.Visible;
				enterbutton.Visibility = ViewStates.Gone;
				spinner.Visibility = ViewStates.Gone;
				resetbutton.Visibility = ViewStates.Visible;

				selectstart.Text = "Select starting units";
				selecttarget.Text = "Select Ending units";

				if (spinner.SelectedItem.ToString() == "Distance")
				{
					startunits.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
					var adapter1 = ArrayAdapter.CreateFromResource(this, Resource.Array.Distance, Android.Resource.Layout.SimpleSpinnerItem);
					adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
					startunits.Adapter = adapter1;

					targetunits.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
					var adapter2 = ArrayAdapter.CreateFromResource(this, Resource.Array.Distance, Android.Resource.Layout.SimpleSpinnerItem);
					adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
					targetunits.Adapter = adapter2;
				}

				else if (spinner.SelectedItem.ToString() == "Weight")
				{
					startunits.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
					var adapter1 = ArrayAdapter.CreateFromResource(this, Resource.Array.Weight, Android.Resource.Layout.SimpleSpinnerItem);
					adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
					startunits.Adapter = adapter1;

					targetunits.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
					var adapter2 = ArrayAdapter.CreateFromResource(this, Resource.Array.Weight, Android.Resource.Layout.SimpleSpinnerItem);
					adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
					targetunits.Adapter = adapter2;
				}

				else if (spinner.SelectedItem.ToString() == "Volume")
				{
					startunits.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
					var adapter1 = ArrayAdapter.CreateFromResource(this, Resource.Array.Volume, Android.Resource.Layout.SimpleSpinnerItem);
					adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
					startunits.Adapter = adapter1;

					targetunits.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
					var adapter2 = ArrayAdapter.CreateFromResource(this, Resource.Array.Volume, Android.Resource.Layout.SimpleSpinnerItem);
					adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
					targetunits.Adapter = adapter2;
				}
				else
				{
					startunits.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
					var adapter1 = ArrayAdapter.CreateFromResource(this, Resource.Array.Temperature, Android.Resource.Layout.SimpleSpinnerItem);
					adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
					startunits.Adapter = adapter1;

					targetunits.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
					var adapter2 = ArrayAdapter.CreateFromResource(this, Resource.Array.Temperature, Android.Resource.Layout.SimpleSpinnerItem);
					adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
					targetunits.Adapter = adapter2;
				}

			};
			convertbutton.Click += (object sender, EventArgs e) =>
			{
				double n;
				string pounds = "";
				pounds = input.Text;

				if (!Double.TryParse(pounds.ToString(), out n))
				{
					output.Text = "Must Give A Number";
				}

				else if (!(Double.Parse(pounds.ToString()) >= 0) && !(spinner.SelectedItem.ToString() == "Temperature"))
				{
					output.Text = "Number Must Be Non-Negative";
				}

				else
				{
					ClassAssign classassign = new ClassAssign();
					output.Text = classassign.call_class(spinner.SelectedItem.ToString(),
														  startunits.SelectedItem.ToString(),
														  targetunits.SelectedItem.ToString(),
														  pounds.ToString()) + " "
															+ targetunits.SelectedItem;


				}
			
			};
			resetbutton.Click += (object sender, EventArgs e) =>
			{
				title.Visibility = ViewStates.Visible;
				startunits.Visibility = ViewStates.Invisible;
				targetunits.Visibility = ViewStates.Invisible;
				selectstart.Visibility = ViewStates.Invisible;
				selecttarget.Visibility = ViewStates.Invisible;
				input.Visibility = ViewStates.Invisible;
				output.Visibility = ViewStates.Gone;
				convertbutton.Visibility = ViewStates.Invisible;
				spinner.Visibility = ViewStates.Visible;
				enternumber.Visibility = ViewStates.Invisible;
				enterbutton.Visibility = ViewStates.Visible;
				resetbutton.Visibility = ViewStates.Gone;
				output.Text = "";
			};
		
		
		}
	}
}


