

import { KyNangDTO } from '@/models/Interview/KyNangDTO';
import { UngVienDTO } from '@/models/Interview/UngVienDTO'; 

export interface KyNangUngVienDTO { 
    id: number;
    tuDanhGia: string;
    tuRating: string;
    hvitDanhGia: string;
    hvitRating: string;
    kyNang: KyNangDTO;
    ungVien: UngVienDTO;
}