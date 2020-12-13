import { HTTP } from '@/HTTPServices';
import { BaseApi } from '@/apiResources/BaseApi';
import { PaginatedResponse, Pagination } from '@/apiResources/PaginatedResponse';
import { HocVienDTO } from '@/models/HocVienDTO';

class AccountApi extends BaseApi {
  getHocVienByUser() {
    return new Promise<HocVienDTO>((resolve: any, reject: any) => {
      HTTP.get(`api/User`)
        .then((response) => {
          resolve(response.data);
        })
        .catch((error) => {
          reject(error);
        });
    });
  }

}
export default new AccountApi();