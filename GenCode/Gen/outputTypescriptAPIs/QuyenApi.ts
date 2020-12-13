

import { HTTP } from '@/HTTPServices';
import { BaseApi } from '@/apiResources/BaseApi';
import { PaginatedResponse, Pagination } from '@/apiResources/PaginatedResponse';
import { QuyenDTO } from '@/models/QuyenDTO';
export interface GetQuyenParams extends Pagination {
   keywords? : string
}

class QuyenApi extends BaseApi {
    
    getQuyen(getQuyenParams: GetQuyenParams) {
        return new Promise<PaginatedResponse<QuyenDTO>>((resolve: any, reject: any) => {
            HTTP.get(`api/Quyen`, { params: getQuyenParams })
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    getQuyenById(id: number) {
        return new Promise<QuyenDTO>((resolve: any, reject: any) => {
            HTTP.get(`api/Quyen/${id}`)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    createQuyen(quyenDTO: QuyenDTO) {
        return new Promise<QuyenDTO>((resolve: any, reject: any) => {
            HTTP.post(`api/Quyen`,quyenDTO)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    updateQuyen(id: number, quyenDTO: QuyenDTO) {
        return new Promise<QuyenDTO>((resolve: any, reject: any) => {
            HTTP.put(`api/Quyen/${id}`,quyenDTO)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    deleteQuyen(id: number) {
        return new Promise<200>((resolve: any, reject: any) => {
            HTTP.delete(`api/Quyen/${id}`)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
}
export default new QuyenApi();
