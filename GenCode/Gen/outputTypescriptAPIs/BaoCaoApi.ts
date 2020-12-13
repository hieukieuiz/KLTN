

import { HTTP } from '@/HTTPServices';
import { BaseApi } from '@/apiResources/BaseApi';
import { PaginatedResponse, Pagination } from '@/apiResources/PaginatedResponse';
import { BaoCaoDTO } from '@/models/BaoCaoDTO';
export interface GetBaoCaoByChiTietCongViecIdParams extends Pagination {
   chiTietCongViecId : number
}

class BaoCaoApi extends BaseApi {
    
    getBaoCaoByChiTietCongViecId(getBaoCaoByChiTietCongViecIdParams: GetBaoCaoByChiTietCongViecIdParams) {
        return new Promise<PaginatedResponse<BaoCaoDTO>>((resolve: any, reject: any) => {
            HTTP.get(`api/BaoCao`, { params: getBaoCaoByChiTietCongViecIdParams })
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    createBaoCao(baoCaoDTO: BaoCaoDTO) {
        return new Promise<BaoCaoDTO>((resolve: any, reject: any) => {
            HTTP.post(`api/BaoCao`,baoCaoDTO)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
}
export default new BaoCaoApi();
