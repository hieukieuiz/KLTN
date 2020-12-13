

import { YeuCauDTO } from '@/models/YeuCauDTO'; 

export interface LoaiYeuCauDTO { 
    id: number;
    tenLoaiYeuCau: string;
    yeuCau: YeuCauDTO[];
}