

import { CVUngVienDTO } from '@/models/CVUngVienDTO'; 

export interface QuaTrinhHocTapDTO { 
    id: number;
    thoiGianBatDau: Date;
    thoiGianKetThuc: Date;
    noiHocTap: string;
    chuyenNganh: string;
    cvUngVien: CVUngVienDTO;
}