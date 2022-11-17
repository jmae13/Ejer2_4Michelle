using Ejer2_4Michelle.Models;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;

namespace Ejer2_4Michelle
{
    public partial class MainPage : ContentPage
    {
        MediaFile FileVideo;
        grabar video = null;

        public MainPage()
        {
            InitializeComponent();
            if (App.DBase != null) { }
        }

        private async void btnVideo_Clicked(object sender, EventArgs e)
        {
            try
            {

                var name = DateTime.Now.ToString("yyyy'-'MM'-'dd'_'HHmmss") + ".mp4";

                FileVideo = await CrossMedia.Current.TakeVideoAsync(new Plugin.Media.Abstractions.StoreVideoOptions
                {
                    SaveToAlbum = true,
                    Name = name,
                    Directory = "Videos"

                });

                if (FileVideo == null)
                    return;


                mediaElement.Source = FileVideo.Path;

                await DisplayAlert("Video guardado en storage", "Path: " + FileVideo.Path, "OK");

                video = new grabar
                {
                    Id = 0,
                    Name = name,
                    Path = FileVideo.Path,
                    Date = DateTime.Now
                };

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (FileVideo == null)
                {
                    await DisplayAlert("Aviso", "Debe tomar un video", "OK");
                    return;
                }

                var result = await App.DBase.insertUpdateVideo(video);

                if (result > 0)
                {
                    await DisplayAlert("Aviso", "Video guardado en base de datos", "OK");

                    FileVideo = null;
                    video = null;
                    mediaElement.Source = null;
                }
                else
                    await DisplayAlert("Aviso", "El video no se pudo guardar en la base de datos", "OK");

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }


        }
    }
}
