

import { CVUngVienDTO } from '@/models/Interview/CVUngVienDTO'; 

export interface BangCapUngVienDTO { 
    id: number;
    ngayCap: Date;
    tenBang: string;
    cvUngVien: CVUngVienDTO;
}