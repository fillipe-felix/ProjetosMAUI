﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppMAUIGallery.Repositories;

namespace AppMAUIGallery.Views;

public partial class Menu : ContentPage
{
    public Menu()
    {
        InitializeComponent();

        var categories = new CategoryRepository().GetCategories();

        foreach (var category in categories)
        {
            var lblCategory = new Label();
            lblCategory.Text = category.Name;
            lblCategory.FontFamily = "OpenSansSemibold";

            MenuContainer.Children.Add(lblCategory);
            foreach (var component in category.Components)
            {
                TapGestureRecognizer tap = new TapGestureRecognizer();
                tap.CommandParameter = component.Page;
                tap.Tapped += OnTapComponent;
                
                var lblComponentTitle = new Label();
                lblComponentTitle.Text = component.Title;
                lblComponentTitle.FontFamily = "OpenSansSemibold";
                lblComponentTitle.Margin = new Thickness(20, 10, 0, 0);
                lblComponentTitle.GestureRecognizers.Add(tap);
                
                var lblComponentDescription = new Label();
                lblComponentDescription.Text = component.Description;
                lblComponentDescription.Margin = new Thickness(20, 10, 0, 0);
                lblComponentDescription.GestureRecognizers.Add(tap);
                
                MenuContainer.Children.Add(lblComponentTitle);
                MenuContainer.Children.Add(lblComponentDescription);
            }
        }
    }

    private void OnTapComponent(object? sender, EventArgs e)
    {
        var label = (Label)sender;
        var tap = (TapGestureRecognizer)label.GestureRecognizers[0];
        var page = (Type)tap.CommandParameter;
        
        ((FlyoutPage)App.Current.MainPage).Detail = new NavigationPage((Page)Activator.CreateInstance(page));
        ((FlyoutPage)App.Current.MainPage).IsPresented = false;
    }

    private void OnTapInicio(object? sender, TappedEventArgs e)
    {
        ((FlyoutPage)App.Current.MainPage).Detail = new NavigationPage(new MainPage());
        ((FlyoutPage)App.Current.MainPage).IsPresented = false;
    }
}

