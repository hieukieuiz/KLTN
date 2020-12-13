

 

export interface UserDTO { 
    lockoutEnd: Date;
    twoFactorEnabled: boolean;
    phoneNumberConfirmed: boolean;
    phoneNumber: string;
    concurrencyStamp: string;
    securityStamp: string;
    passwordHash: string;
    emailConfirmed: boolean;
    normalizedEmail: string;
    email: string;
    normalizedUserName: string;
    userName: string;
    id: string;
    lockoutEnabled: boolean;
    accessFailedCount: number;
    password: string;
    roles: string[];
}