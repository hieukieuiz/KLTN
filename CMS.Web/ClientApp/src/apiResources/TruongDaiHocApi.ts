

import { HTTP } from '@/HTTPServices';
import { BaseApi } from '@/apiResources/BaseApi';
import { PaginatedResponse, Pagination } from '@/apiResources/PaginatedResponse';
import { TruongDaiHocDTO } from '@/models/TruongDaiHocDTO';
export interface GetTruongDaiHocParams extends Pagination {
    keywords? : string
}

class TruongDaiHocApi extends BaseApi {
    
    getTruongDaiHoc(getTruongDaiHocParams: GetTruongDaiHocParams) {
        return new Promise<PaginatedResponse<TruongDaiHocDTO>>((resolve: any, reject: any) => {
            HTTP.get(`api/TruongDaiHoc`, { params: getTruongDaiHocParams })
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    getTruongDaiHocById(id: number) {
        return new Promise<TruongDaiHocDTO>((resolve: any, reject: any) => {
            HTTP.get(`api/TruongDaiHoc/${id}`)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    createTruongDaiHoc(truongDaiHocDTO: TruongDaiHocDTO) {
        return new Promise<TruongDaiHocDTO>((resolve: any, reject: any) => {
            HTTP.post(`api/TruongDaiHoc`,truongDaiHocDTO)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    updateTruongDaiHoc(id: number, truongDaiHocDTO: TruongDaiHocDTO) {
        return new Promise<TruongDaiHocDTO>((resolve: any, reject: any) => {
            HTTP.put(`api/TruongDaiHoc/${id}`,truongDaiHocDTO)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    deleteTruongDaiHoc(id: number) {
        return new Promise<200>((resolve: any, reject: any) => {
            HTTP.delete(`api/TruongDaiHoc/${id}`)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
}
export default new TruongDaiHocApi();
