<template>
    <v-app light>
        <left-side-bar v-if="isLoggedIn"></left-side-bar>
        <v-app-bar v-if="isLoggedIn && $vuetify.breakpoint.smAndUp" id="headermenu" color="#4267B2" dark app height="45">
            <v-app-bar-nav-icon @click.stop="updateDrawer"></v-app-bar-nav-icon>
            <v-toolbar-title v-text="title"></v-toolbar-title>
            <v-spacer></v-spacer>
            <v-menu offset-y>
                <template v-slot:activator="{ on }">
                    <v-btn icon v-on="on" dark>
                        <v-avatar size="32px">
                            <!-- <v-icon>account_circle</v-icon> -->
                            <v-icon>mdi-dots-vertical</v-icon>
                        </v-avatar>
                    </v-btn>
                </template>
                <v-list>
                    <v-list-item :href="'/identity/account/manage'">
                        <v-list-item-title>Tài khoản của tôi</v-list-item-title>
                    </v-list-item>
                    <v-list-item @click="logout">
                        <v-list-item-title>Đăng xuất</v-list-item-title>
                    </v-list-item>
                </v-list>
            </v-menu>
        </v-app-bar>
        <v-content style="background-color: #F0F2F5; padding-top:0; padding-bottom:50px;" class="pt-sm-11 pb-sm-0">
            <!-- <v-container fluid  grid-list-md class="pa-0"> -->
                <router-view></router-view>
                <vue-snotify></vue-snotify>
            <!-- </v-container> -->
        </v-content>
    </v-app>
</template>
<script lang="ts">
    import "vue-snotify/styles/material.css";
    import { Vue } from "vue-property-decorator";
    import LeftSideBar from "@/components/Layout/LeftSideBar.vue";
    import AuthService from "@/AuthService";
    const auth2 = new AuthService();

    export default Vue.extend({
        name: "App",
        components: { LeftSideBar },
        data() {
            return {
                bottomNav: null,
                clipped: false,
                drawer: this.$store.state.app.drawer,
                fixed: true,
                miniVariant: false,
                right: true,
                rightDrawer: false,
                title: "",
                user: this.$store.state.user.Profile,
                myProfile: {} as any,
                totalUnSeenChatMessages: 0
            };
        },
        computed: {
            isLoggedIn(): boolean {
                return true;
                // this.user = this.$store.state.user.Profile;
                // return (
                //   this.$store.state.user &&
                //   this.$store.state.user.AccessToken &&
                //   this.$store.state.user.AccessToken.IsAuthenticated
                // );
            }
        },
        created() {
            
        },
        mounted() {
            this.$store.commit("CLEAR_ALL_DATA");
        },
        methods: {
            checkRole(roleId: number): boolean {
                return this.$store.state.user.Profile.UserRole.indexOf(roleId) !== -1;
            },
            logout() {
                this.$store.commit("CLEAR_ALL_DATA");
                window.location.href = '/identity/account/manage/confirmlogout';
            },
            updateDrawer() {
                let app = this.$store.state.app;
                app.drawer = !this.$store.state.app.drawer;
                this.$store.commit("UPDATE_APP", app);
            },
        }
    });
</script>
<style>
    #appDrawer {
        overflow: hidden;
    }

        #appDrawer .v-list__tile__action,
        #appDrawer .v-list__group__header .v-list__group__header__prepend-icon {
            min-width: 35px;
        }

        #appDrawer .v-list__group__header .v-list__group__header__prepend-icon {
            padding-right: 0;
        }

        #appDrawer .v-list__group__items--no-action .v-list__tile {
            padding-left: 35px;
        }

        #appDrawer .v-toolbar {
            box-shadow: 0 1px 2px rgba(0, 0, 0, 0.2);
        }

    .drawer-menu--scroll {
        height: calc(100vh - 100px);
        overflow: auto;
    }

    #headermenu .v-text-field.v-text-field--solo .v-input__control {
        min-height: 35px;
    }

    .v-select__selections,
    .v-chip,
    .v-chip__content,
    .v-chip__content span {
        max-width: 100%;
    }

    #headermenu {
        box-shadow: 0 1px 2px rgba(0, 0, 0, 0.2);
    }
</style>