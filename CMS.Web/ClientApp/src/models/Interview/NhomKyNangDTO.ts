

import { KyNangDTO } from '@/models/Interview/KyNangDTO'; 

export interface NhomKyNangDTO { 
    id: number;
    tenNhomKyNang: string;
    kyNang: KyNangDTO[];
}