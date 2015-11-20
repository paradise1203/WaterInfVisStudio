using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу http://go.microsoft.com/fwlink/?LinkId=391641

namespace WaterInf
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Вызывается перед отображением этой страницы во фрейме.
        /// </summary>
        /// <param name="e">Данные события, описывающие, каким образом была достигнута эта страница.
        /// Этот параметр обычно используется для настройки страницы.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Подготовьте здесь страницу для отображения.

            // TODO: Если приложение содержит несколько страниц, обеспечьте
            // обработку нажатия аппаратной кнопки "Назад", выполнив регистрацию на
            // событие Windows.Phone.UI.Input.HardwareButtons.BackPressed.
            // Если вы используете NavigationHelper, предоставляемый некоторыми шаблонами,
            // данное событие обрабатывается для вас.
        }

        private async void button_login_click(object sender, RoutedEventArgs e)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("http://10.1.79.160:8080/mobile/login/");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            var s = await httpWebRequest.GetRequestStreamAsync();
            var login = textBox_username.Text;
            var password = textBox_password.Text;
            using (var streamWriter = new StreamWriter(s, Encoding.UTF8))
            {
                string json = "{\"login\":\""+login+ "\",\"password\":\"" + password + "\"}";
                streamWriter.Write(json);
                streamWriter.Flush();
            }
            var httpResponse = await httpWebRequest.GetResponseAsync();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }
        }
        /*
private async void getBtn(object sender, RoutedEventArgs e)
{
   HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("http://10.1.79.160:8080/mobile/login/");
   httpWebRequest.ContentType = "application/json";
   httpWebRequest.Method = "POST";
   var s = await httpWebRequest.GetRequestStreamAsync();
   using (var streamWriter = new StreamWriter(s,Encoding.UTF8))
   {
       // string json = "{\"bottle\":\"test\"," +
       // "\"password\":\"bla\"}";
       string json = "{\"login\":\"test1\",\"password\":\"123456\"}";

       streamWriter.Write(json);
       streamWriter.Flush();
   }

   var httpResponse = await httpWebRequest.GetResponseAsync();
   using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
   {
       var result = streamReader.ReadToEnd();
   }
}
*/

    }
}
