

import { ChiTietCongViecDTO } from '@/models/ChiTietCongViecDTO';
import { ThanhVienDuAnDTO } from '@/models/ThanhVienDuAnDTO'; 

export interface BaoCaoDTO { 
    id: number;
    chiTietCongViecId: number;
    thanhVienDuAnId: number;
    noiDung: string;
    thoiGianTao: Date;
    chiTietCongViec: ChiTietCongViecDTO;
    thanhVienDuAn: ThanhVienDuAnDTO;
}