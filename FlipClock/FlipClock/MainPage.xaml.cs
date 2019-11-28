using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using FlipClock.Modelo;

namespace FlipClock
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        int i_s_t = 0;
        int i_s_u = 0;
        int i_m_t = 0;
        int i_m_u = 0;
        int i_h_t = 0;
        int i_h_u = 0;
        Clock _flipClock;
        uint configure_flip_time_set;

        public MainPage()
        {
            InitializeComponent();
            _flipClock = new Clock(i_h_t,i_h_u, i_m_t, i_m_u, i_s_t, i_s_u);
            initFlipClock();
            configure_flip_time_set = 50;
        }

        private void initFlipClock()
        {
            FlipRotator(up_image_second_tenth_view, down_image_second_tenth_view, _flipClock.getSecondTenth());
            FlipRotator(up_image_second_unit_view, down_image_second_unit_view, _flipClock.getSecondUnit());

            FlipRotator(up_image_minute_tenth_view, down_image_minute_tenth_view, _flipClock.getMinuteTenth());
            FlipRotator(up_image_minute_unit_view, down_image_minute_unit_view, _flipClock.getMinuteUnit());

            FlipRotator(up_image_hour_tenth_view, down_image_hour_tenth_view, _flipClock.getHourTenth());
            FlipRotator(up_image_hour_unit_view, down_image_hour_unit_view, _flipClock.getHourUnit());
        }

        private void MoverFlipClock_Clicked(object sender, EventArgs e)
        {
            MoveClockMeter();
        }

        private void PonerEnHoraFlipClock_Clicked(object sender, EventArgs e)
        {
            try
            {
                _flipClock.setHours(int.Parse(Hd.SelectedItem.ToString()), int.Parse(Hu.SelectedItem.ToString()));
                _flipClock.setMinutes(int.Parse(Md.SelectedItem.ToString()), int.Parse(Mu.SelectedItem.ToString()));
                _flipClock.setSeconds(int.Parse(Sd.SelectedItem.ToString()), int.Parse(Su.SelectedItem.ToString()));
                initFlipClock();
            }
            catch(NullReferenceException ex)
            {
                DisplayAlert(ex.ToString(),"Debe rellenar todos los campos para poner en hora","Ok");
            }
        }


        private void MoveClockMeter()
        {
            int s_u = _flipClock.getSecondUnit();
            int s_t = _flipClock.getSecondTenth();
            int m_u = _flipClock.getMinuteUnit();
            int m_t = _flipClock.getMinuteTenth();
            int h_u = _flipClock.getHourUnit();
            int h_t = _flipClock.getHourTenth();

            _flipClock.stepClock();

            FlipRotator(up_image_second_tenth_view, down_image_second_tenth_view, s_t);
            FlipRotator(up_image_second_unit_view, down_image_second_unit_view, s_u);

            FlipRotator(up_image_minute_tenth_view, down_image_minute_tenth_view, m_t);
            FlipRotator(up_image_minute_unit_view, down_image_minute_unit_view, m_u);

            FlipRotator(up_image_hour_tenth_view, down_image_hour_tenth_view, h_t);
            FlipRotator(up_image_hour_unit_view, down_image_hour_unit_view, h_u);

        }


        private async void FlipRotator(Image up_image, Image down_image, int flip_nro)
        {
            await up_image.RotateXTo(-180,configure_flip_time_set, Easing.CubicIn);
            up_image.SetValue(Image.SourceProperty, $"up_{flip_nro}.png");
            await up_image.RotateXTo(0, configure_flip_time_set, Easing.CubicIn);

            await down_image.RotateXTo(180, configure_flip_time_set, Easing.CubicIn);
            down_image.SetValue(Image.SourceProperty, $"down_{flip_nro}.png");
            await down_image.RotateXTo(360, configure_flip_time_set / 10, Easing.CubicIn);
        }
    }
}
