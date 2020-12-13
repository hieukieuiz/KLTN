

import { HocVienDTO } from '@/models/HocVienDTO'; 

export interface TruongDaiHocDTO { 
    id: number;
    tenTruongDaiHoc: string;
    hocVien: HocVienDTO[];
}