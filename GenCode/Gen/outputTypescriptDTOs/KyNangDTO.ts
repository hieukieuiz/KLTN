

import { NhomKyNangDTO } from '@/models/NhomKyNangDTO';
import { KyNangUngVienDTO } from '@/models/KyNangUngVienDTO'; 

export interface KyNangDTO { 
    id: number;
    tenKyNang: string;
    nhomKyNang: NhomKyNangDTO;
    kyNangUngVien: KyNangUngVienDTO[];
}