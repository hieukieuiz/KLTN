

import { UngVienDTO } from '@/models/UngVienDTO';
import { QuaTrinhHocTapDTO } from '@/models/QuaTrinhHocTapDTO';
import { BangCapUngVienDTO } from '@/models/BangCapUngVienDTO';
import { QuaTrinhLamDuAnDTO } from '@/models/QuaTrinhLamDuAnDTO'; 

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