

import { CVUngVienDTO } from '@/models/Interview/CVUngVienDTO'; 

export interface QuaTrinhHocTapDTO { 
    id: number;
    thoiGianBatDau: Date;
    thoiGianKetThuc: Date;
    noiHocTap: string;
    chuyenNganh: string;
    cvUngVien: CVUngVienDTO;
}