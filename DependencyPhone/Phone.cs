using System;
using System.Windows;

namespace DependencyPhone;

public class Phone : DependencyObject
{
    public static readonly DependencyProperty NameProperty;
    public static readonly DependencyProperty PriceProperty;

    static Phone()
    {
        NameProperty = DependencyProperty.Register("Name", typeof(string), typeof(Phone));
        FrameworkPropertyMetadata metadata = new FrameworkPropertyMetadata();
        metadata.CoerceValueCallback = new CoerceValueCallback(CorrectValue);
        PriceProperty = DependencyProperty.Register("Price", typeof(int), typeof(Phone), metadata, new ValidateValueCallback(ValidateValue));
    }

    private static object CorrectValue(DependencyObject d, object baseValue)
    {
        int currentValue = (int)baseValue;
        if (currentValue > 5000)
        {
            return 5000;
        }

        if (currentValue < 0)
        {
            return Math.Abs(currentValue);
        }

        return currentValue;
    }

    private static bool ValidateValue(object value)
    {
        return true;
    }

    public string Name
    {
        get { return (string)GetValue(NameProperty); }
        set { SetValue(NameProperty, value); }
    }
    
    public int Price
    {
        get { return (int)GetValue(PriceProperty); }
        set { SetValue(PriceProperty, value); }
    }
}