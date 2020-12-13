

import { TrangThaiDTO } from '@/models/TrangThaiDTO';
import { ChiTietCongViecDTO } from '@/models/ChiTietCongViecDTO';
import { ThanhVienDuAnDTO } from '@/models/ThanhVienDuAnDTO'; 

export interface LichSuChiTietCongViecDTO { 
    id: number;
    trangThaiId: number;
    chiTietCongViecId: number;
    thanhVienDuAnId: number;
    ngayCapNhat: Date;
    soLuongThanhVien: number;
    thuTu: number;
    ghiChu: string;
    trangThai: TrangThaiDTO;
    chiTietCongViec: ChiTietCongViecDTO;
    thanhVienDuAn: ThanhVienDuAnDTO;
}