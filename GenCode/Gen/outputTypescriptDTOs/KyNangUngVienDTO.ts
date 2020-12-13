

import { KyNangDTO } from '@/models/KyNangDTO';
import { UngVienDTO } from '@/models/UngVienDTO'; 

export interface KyNangUngVienDTO { 
    id: number;
    tuDanhGia: string;
    tuRating: string;
    hvitDanhGia: string;
    hvitRating: string;
    kyNang: KyNangDTO;
    ungVien: UngVienDTO;
}