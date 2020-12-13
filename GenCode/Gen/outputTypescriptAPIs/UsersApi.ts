

import { HTTP } from '@/HTTPServices';
import { BaseApi } from '@/apiResources/BaseApi';
import { PaginatedResponse, Pagination } from '@/apiResources/PaginatedResponse';
import { Liststring } from '@/models/Liststring';
import { UserDTO } from '@/models/UserDTO';
export interface GetUsersParams extends Pagination {
   keywords? : string
   roles? : string[]
}

class UsersApi extends BaseApi {
    
    getMyRoles() {
        return new Promise<Liststring[]>((resolve: any, reject: any) => {
            HTTP.get(`api/Users/myaccount/roles`)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    getUsers(getUsersParams: GetUsersParams) {
        return new Promise<PaginatedResponse<UserDTO>>((resolve: any, reject: any) => {
            HTTP.get(`api/Users`, { params: getUsersParams })
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    createUser(user: UserDTO) {
        return new Promise<UserDTO>((resolve: any, reject: any) => {
            HTTP.post(`api/Users`,user)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    updateUser(user: UserDTO) {
        return new Promise<UserDTO>((resolve: any, reject: any) => {
            HTTP.put(`api/Users`,user)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    resetPassword(user: UserDTO) {
        return new Promise<200>((resolve: any, reject: any) => {
            HTTP.post(`api/Users/resetpassword`,user)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
    deleteUser(userName: string) {
        return new Promise<200>((resolve: any, reject: any) => {
            HTTP.delete(`api/Users/${encodeURIComponent(userName)}`)
            .then((response) => {
                resolve(response.data);
            }).catch((error) => {
                reject(error);
            })
        });
    }
}
export default new UsersApi();
