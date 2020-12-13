

import { CVUngVienDTO } from '@/models/CVUngVienDTO'; 

export interface BangCapUngVienDTO { 
    id: number;
    ngayCap: Date;
    tenBang: string;
    cvUngVien: CVUngVienDTO;
}