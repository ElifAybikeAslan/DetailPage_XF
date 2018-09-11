using DetailPage_XF.MenuItems;
using DetailPage_XF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DetailPage_XF
{
	public partial class MainPage : MasterDetailPage
	{
        public List<MasterPageItem> menuList { get; set; }

        public MainPage()
		{
			InitializeComponent();

            menuList = new List<MasterPageItem>();

            var pageAnasayfa = new MasterPageItem() { Title = "Anasayfa", Icon = "anasayfa.png", TargetType = typeof(Anasayfa) };
            var pageProfil = new MasterPageItem() { Title = "Profil", Icon = "profil.png", TargetType = typeof(Profil) };
            var pageBileklikTanim = new MasterPageItem() { Title = "Bileklik Tanım", Icon = "bilekliktanim.png", TargetType = typeof(BileklikTanim) };
            var pageAyarlar = new MasterPageItem() { Title = "Ayarlar", Icon = "ayarlar.png", TargetType = typeof(Ayarlar) };


            menuList.Add(pageAnasayfa);
            menuList.Add(pageProfil);
            menuList.Add(pageBileklikTanim);
            menuList.Add(pageAyarlar);

            navigationDrawerList.ItemsSource = menuList;

            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(Anasayfa)));

            this.BindingContext = new
            {
                Header = "",
                Image = "profileImage.png",
                Footer = "Elif Aybike Aslan"
            };
        }

        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.TargetType;

            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }
    }
	}

