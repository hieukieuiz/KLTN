

import { KyNangDTO } from '@/models/KyNangDTO'; 

export interface NhomKyNangDTO { 
    id: number;
    tenNhomKyNang: string;
    kyNang: KyNangDTO[];
}