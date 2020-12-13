

import { UngVienDTO } from '@/models/Interview/UngVienDTO';
import { QuaTrinhHocTapDTO } from '@/models/Interview/QuaTrinhHocTapDTO';
import { BangCapUngVienDTO } from '@/models/Interview/BangCapUngVienDTO';
import { QuaTrinhLamDuAnDTO } from '@/models/Interview/QuaTrinhLamDuAnDTO'; 

export interface CVUngVienDTO { 
    id: number;
    ngaySinh: string;
    gioiTinh: string;
    diaChi: string;
    mucTieuCaNhan: string;
    soThich: string;
    ungVien: UngVienDTO;
    quaTrinhHocTap: QuaTrinhHocTapDTO[];
    bangCapUngVien: BangCapUngVienDTO[];
    quaTrinhLamDuAn: QuaTrinhLamDuAnDTO[];
}