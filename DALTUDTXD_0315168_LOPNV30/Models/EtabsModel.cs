using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows; // để dùng MessageBox
using System.Windows.Controls.Ribbon; // Thêm thư viện này để dùng RibbonButton
using ETABSv1; // ETABS 22 API

namespace DALTUDTXD_0315168_LOPNV30.Models
{
    public class EtabsModel
    {
        public cSapModel SapModel { get; private set; }
        private cHelper Helper;
        private cOAPI EtabsObject;
        public bool IsConnected => SapModel != null;
        public string ModelName => IsConnected ? Path.GetFileName(SapModel.GetModelFilename()) : "";

        /// <summary>
        /// Hàm thực hiện kết nối tới phần mềm ETABS đang mở
        /// </summary>
        public bool ConnectToEtabs()
        {
            try
            {
                Helper = new Helper();

                try
                {
                    // Lấy đối tượng ETABS đang chạy (sẽ kết nối tới bản ETABS đang mở sẵn)
                    EtabsObject = Helper.GetObject("CSI.ETABS.API.ETABSObject");
                }
                catch (Exception)
                {
                    MessageBox.Show("Không tìm thấy phần mềm ETABS đang chạy. Hãy mở ETABS và mở file mô hình trước.",
                                    "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }

                if (EtabsObject == null)
                {
                    MessageBox.Show("Không thể khởi tạo API kết nối với ETABS.",
                                    "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }

                SapModel = EtabsObject.SapModel;

                // Kiểm tra xem đã mở file .edb chưa
                string modelPath = SapModel.GetModelFilename();
                if (string.IsNullOrEmpty(modelPath))
                {
                    MessageBox.Show("Đã kết nối ETABS nhưng bạn chưa mở file mô hình .edb nào. Vui lòng mở file mô hình và thử lại.",
                                    "Lưu ý", MessageBoxButton.OK, MessageBoxImage.Information);
                    // Dù kết nối được nhưng chưa mở file thì hàm trả về false để ngăn các chức năng khác chạy
                    return false;
                }
                else
                {
                    MessageBox.Show($"Đã kết nối ETABS thành công!\nMô hình hiện tại: {Path.GetFileName(modelPath)}",
                                    "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không kết nối được ETABS. Chi tiết lỗi: " + ex.Message,
                                "Lỗi kết nối", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
    }
}
