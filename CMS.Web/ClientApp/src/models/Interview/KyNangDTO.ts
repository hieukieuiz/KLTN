

import { NhomKyNangDTO } from '@/models/Interview/NhomKyNangDTO';
import { KyNangUngVienDTO } from '@/models/Interview/KyNangUngVienDTO'; 

export interface KyNangDTO { 
    id: number;
    tenKyNang: string;
    nhomKyNang: NhomKyNangDTO;
    kyNangUngVien: KyNangUngVienDTO[];
}