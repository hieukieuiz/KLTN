

import { HTTP } from '@/HTTPServices';
import { BaseApi } from '@/apiResources/BaseApi';
import { PaginatedResponse, Pagination } from '@/apiResources/PaginatedResponse';
import { QuyenDuAnDTO } from '@/models/QuyenDuAnDTO';
export interface GetQuyenDuAnParams extends Pagination {
   duAnId: number,
}

class QuyenDuAnApi extends BaseApi {
    
    getQuyenDuAnByDuAnId(getQuyenDuAnParams: GetQuyenDuAnParams) {
        return new Promise<PaginatedResponse<QuyenDuAnDTO>>((resolve: any, reject: any) => {
            HTTP.get(`api/QuyenDuAn`, { params: getQuyenDuAnParams })
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    
    getQuyenDuAnById(id: number) {
        return new Promise<QuyenDuAnDTO>((resolve: any, reject: any) => {
            HTTP.get(`api/QuyenDuAn/${id}`)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    createQuyenDuAn(quyenDuAnDTO: QuyenDuAnDTO) {
        return new Promise<QuyenDuAnDTO>((resolve: any, reject: any) => {
            HTTP.post(`api/QuyenDuAn`,quyenDuAnDTO)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    updateQuyenDuAn(id: number, quyenDuAnDTO: QuyenDuAnDTO) {
        return new Promise<QuyenDuAnDTO>((resolve: any, reject: any) => {
            HTTP.put(`api/QuyenDuAn/${id}`,quyenDuAnDTO)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    deleteQuyenDuAn(id: number) {
        return new Promise<200>((resolve: any, reject: any) => {
            HTTP.delete(`api/QuyenDuAn/${id}`)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
}
export default new QuyenDuAnApi();
