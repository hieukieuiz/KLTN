

import { HTTP } from '@/HTTPServices';
import { BaseApi } from '@/apiResources/BaseApi';
import { PaginatedResponse, Pagination } from '@/apiResources/PaginatedResponse';
import { TrangThaiDuAnDTO } from '@/models/TrangThaiDuAnDTO';
export interface GetTrangThaiDuAnByDuAnIdParams extends Pagination {
   duAnId : number
   tenCongViec? : string
   loaiCongViecId? : number
}

class TrangThaiDuAnApi extends BaseApi {
    
    getTrangThaiDuAnByDuAnId(getTrangThaiDuAnByDuAnIdParams: GetTrangThaiDuAnByDuAnIdParams) {
        return new Promise<PaginatedResponse<TrangThaiDuAnDTO>>((resolve: any, reject: any) => {
            HTTP.get(`api/TrangThaiDuAn`, { params: getTrangThaiDuAnByDuAnIdParams })
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    createTrangThaiDuAn(trangThaiDuAnDTO: TrangThaiDuAnDTO) {
        return new Promise<TrangThaiDuAnDTO>((resolve: any, reject: any) => {
            HTTP.post(`api/TrangThaiDuAn`,trangThaiDuAnDTO)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    updateTrangThaiDuAn(id: number, trangThaiDuAnDTO: TrangThaiDuAnDTO) {
        return new Promise<TrangThaiDuAnDTO>((resolve: any, reject: any) => {
            HTTP.put(`api/TrangThaiDuAn/${id}`,trangThaiDuAnDTO)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    deleteTrangThaiDuAn(id: number) {
        return new Promise<200>((resolve: any, reject: any) => {
            HTTP.delete(`api/TrangThaiDuAn/${id}`)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
}
export default new TrangThaiDuAnApi();
