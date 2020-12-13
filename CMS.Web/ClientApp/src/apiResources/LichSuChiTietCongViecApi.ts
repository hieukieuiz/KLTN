import { HTTP } from "@/HTTPServices";
import { BaseApi } from "@/apiResources/BaseApi";
import {
  PaginatedResponse,
  Pagination,
} from "@/apiResources/PaginatedResponse";
import { LichSuChiTietCongViecDTO } from "@/models/LichSuChiTietCongViecDTO";
export interface GetLichSuChiTietCongViecParams extends Pagination {
  trangThaiId?: number;
  chiTietCongViecId: number;
  thanhVienDuAnId?:number
  
}

class LichSuChiTietCongViecApi extends BaseApi {
  getLichSuChiTietCongViec(getLichSuChiTietCongviecParams: GetLichSuChiTietCongViecParams) {
    return new Promise<PaginatedResponse<LichSuChiTietCongViecDTO>>(
      (resolve: any, reject: any) => {
        HTTP.get(`api/LichSuChiTietCongViec`, { params: getLichSuChiTietCongviecParams })
          .then((response) => {
            resolve(response.data);
          })
          .catch((error) => {
            reject(error);
          });
      }
    );
  }
  getLichSuChiTietCongViecById(id: number) {
    return new Promise<LichSuChiTietCongViecDTO>((resolve: any, reject: any) => {
      HTTP.get(`api/LichSuChiTietCongViec/${id}`)
        .then((response) => {
          resolve(response.data);
        })
        .catch((error) => {
          reject(error);
        });
    });
  }
  createLichSuChiTietCongViec(lichSuChiTietCongViecDTO: LichSuChiTietCongViecDTO) {
    return new Promise<LichSuChiTietCongViecDTO>((resolve: any, reject: any) => {
      HTTP.post(`api/LichSuChiTietCongViec`, lichSuChiTietCongViecDTO)
        .then((response) => {
          resolve(response.data);
        })
        .catch((error) => {
          reject(error);
        });
    });
  }
  updateLichSuChiTietCongViec(id: number, lichSuChiTietCongViecDTO: LichSuChiTietCongViecDTO) {
    return new Promise<LichSuChiTietCongViecDTO>((resolve: any, reject: any) => {
      HTTP.put(`api/LichSuChiTietCongViec/${id}`, lichSuChiTietCongViecDTO)
        .then((response) => {
          resolve(response.data);
        })
        .catch((error) => {
          reject(error);
        });
    });
  }
  deleteLichSuChiTietCongViec(id: number) {
    return new Promise<200>((resolve: any, reject: any) => {
      HTTP.delete(`api/LichSuChiTietCongviec/${id}`)
        .then((response) => {
          resolve(response.data);
        })
        .catch((error) => {
          reject(error);
        });
    });
  }
}
export default new LichSuChiTietCongViecApi();