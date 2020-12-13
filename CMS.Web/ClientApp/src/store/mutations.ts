export default {
    UPDATE_APP(state: any, app: any) {
        state.app = app
    },
    UPDATE_USER(state: any, user: any) {
        state.user = user
    },
    UPDATE_USER_ROLES(state: any, userRoles: any) {
        state.user.Profile.UserRoles = userRoles
    },
    UPDATE_DAYSPAN(state: any, daySpanState: any) {
        state.daySpanState = daySpanState
    },
    CLEAR_ALL_DATA(state: any) {
        state.user = {
            AccessToken: {
                IsAuthenticated: false,
                Token: null,
                UserName: null,
                RefreshToken: null,
                EffectiveTime: null,
                ExpiresTime: null
            },
            Profile: {
                UserId: null,
                Username: null,
                Email: null,
                UserRoles: []
            }
        }
    },
    UPDATE_ACADEMICYEAR(state: any, academicYear: any) {
        state.user.Profile.AcademicYear = academicYear
    }
}
