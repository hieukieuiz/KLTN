

import { HTTP } from '@/HTTPServices';
import { BaseApi } from '@/apiResources/BaseApi';
import { PaginatedResponse, Pagination } from '@/apiResources/PaginatedResponse';
import { ChiTietCongViecDTO } from '@/models/ChiTietCongViecDTO';
export interface GetChiTietCongViecByCongViecIdParams extends Pagination {
   congViecId : number
}

class ChiTietCongViecApi extends BaseApi {
    
    getChiTietCongViecByCongViecId(getChiTietCongViecByCongViecIdParams: GetChiTietCongViecByCongViecIdParams) {
        return new Promise<PaginatedResponse<ChiTietCongViecDTO>>((resolve: any, reject: any) => {
            HTTP.get(`api/ChiTietCongViec`, { params: getChiTietCongViecByCongViecIdParams })
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    createChitietCongViec(chiTietCongViecDTO: ChiTietCongViecDTO) {
        return new Promise<ChiTietCongViecDTO>((resolve: any, reject: any) => {
            HTTP.post(`api/ChiTietCongViec`,chiTietCongViecDTO)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    updateChiTietCongViec(id: number, chiTietCongViecDTO: ChiTietCongViecDTO) {
        return new Promise<ChiTietCongViecDTO>((resolve: any, reject: any) => {
            HTTP.put(`api/ChiTietCongViec/${id}`,chiTietCongViecDTO)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    deleteChiTietCongViec(id: number) {
        return new Promise<200>((resolve: any, reject: any) => {
            HTTP.delete(`api/ChiTietCongViec/${id}`)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
}
export default new ChiTietCongViecApi();
