

import { CVUngVienDTO } from '@/models/CVUngVienDTO'; 

export interface QuaTrinhLamDuAnDTO { 
    id: number;
    thoiGianBatDau: Date;
    thoiGianKetThuc: Date;
    tenCongTy: string;
    viTri: string;
    moTaNganDuAn: string;
    kyNang: string;
    cvUngVien: CVUngVienDTO;
}