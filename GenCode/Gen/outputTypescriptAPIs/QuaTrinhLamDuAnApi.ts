

import { HTTP } from '@/HTTPServices';
import { BaseApi } from '@/apiResources/BaseApi';
import { PaginatedResponse, Pagination } from '@/apiResources/PaginatedResponse';
import { QuaTrinhLamDuAnDTO } from '@/models/QuaTrinhLamDuAnDTO';
export interface GetQuaTrinhLamDuAnParams extends Pagination {
   keywords? : string
}

class QuaTrinhLamDuAnApi extends BaseApi {
    
    getQuaTrinhLamDuAn(getQuaTrinhLamDuAnParams: GetQuaTrinhLamDuAnParams) {
        return new Promise<PaginatedResponse<QuaTrinhLamDuAnDTO>>((resolve: any, reject: any) => {
            HTTP.get(`api/QuaTrinhLamDuAn`, { params: getQuaTrinhLamDuAnParams })
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    getQuaTrinhLamDuAnById(id: number) {
        return new Promise<QuaTrinhLamDuAnDTO>((resolve: any, reject: any) => {
            HTTP.get(`api/QuaTrinhLamDuAn/${id}`)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    createQuaTrinhLamDuAn(quaTrinhLamDuAnDTO: QuaTrinhLamDuAnDTO) {
        return new Promise<QuaTrinhLamDuAnDTO>((resolve: any, reject: any) => {
            HTTP.post(`api/QuaTrinhLamDuAn`,quaTrinhLamDuAnDTO)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    updateQuaTrinhLamDuAn(id: number, quaTrinhLamDuAnDTO: QuaTrinhLamDuAnDTO) {
        return new Promise<QuaTrinhLamDuAnDTO>((resolve: any, reject: any) => {
            HTTP.put(`api/QuaTrinhLamDuAn/${id}`,quaTrinhLamDuAnDTO)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    deleteQuaTrinhLamDuAn(id: number) {
        return new Promise<200>((resolve: any, reject: any) => {
            HTTP.delete(`api/QuaTrinhLamDuAn/${id}`)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
}
export default new QuaTrinhLamDuAnApi();
