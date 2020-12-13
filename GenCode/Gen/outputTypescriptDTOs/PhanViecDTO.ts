

import { ThanhVienDuAnDTO } from '@/models/ThanhVienDuAnDTO'; 

export interface PhanViecDTO { 
    id: number;
    congViecId: number;
    thanhVienDuAnId: number;
    thanhVienDuAn: ThanhVienDuAnDTO;
    ngayPhanViec: Date;
}