

import { QuyenDuAnDTO } from '@/models/QuyenDuAnDTO';
import { HocVienDTO } from '@/models/HocVienDTO'; 

export interface ThanhVienDuAnDTO { 
    id: number;
    quyenDuAnId: number;
    hocVienId: number;
    ngayThamGia: Date;
    ghiChu: string;
    quyenDuAn: QuyenDuAnDTO;
    hocVien: HocVienDTO;
}