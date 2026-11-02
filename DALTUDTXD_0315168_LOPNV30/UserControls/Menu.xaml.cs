using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DALTUDTXD_0315168_LOPNV30.UserControls
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : UserControl
    {
        public Menu()
        {
            InitializeComponent();
        }
        // Tạo một biến static để lưu trữ kết nối ETABS dùng chung cho toàn ứng dụng
        public static Models.EtabsModel SharedEtabsModel = new Models.EtabsModel();

        private void Btn_Etabs_Click(object sender, RoutedEventArgs e)
        {
            // Thay vì mở cửa sổ chạy thanh tiến trình giả, gọi thẳng vào hàm kết nối thật
            SharedEtabsModel.ConnectToEtabs();
            rtb_Model.Text = "Thành công ";
        }
        private void Ribbon_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource != sender) return;
            // xử lý khi đổi tab (có thể để trống)
        }
        private void Btn_tinhtoan_Click(object sender, RoutedEventArgs e)
        {
            // TODO: xử lý nút Tính toán
        }

        private void Btn_Excel_Click(object sender, RoutedEventArgs e)
        {
            // TODO: xuất Excel
        }

        private void Btn_PDF_Click(object sender, RoutedEventArgs e)
        {
            // TODO: xuất PDF
        }

        private void Btn_Vatlieu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Taitrong_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
