${
    using System.IO;
    using Typewriter.Extensions.Types;
    Template(Settings settings)
    {
        settings
            .IncludeProject("Annotation.Models");
        settings.OutputExtension = ".vue";
        settings.OutputFilenameFactory = file => 
        {
            return $"outputViews/DanhSach{file.Name.Replace("Dto", "").Replace(".cs", ".vue")}";
        };
    }
    string ImportsList(Class c)
    {
        IEnumerable<Type> types = c.Properties
            .Select(p => p.Type)
            .Where(t => !t.IsPrimitive || t.IsEnum)
            .Select(t => t.IsGeneric ? t.TypeArguments.First() : t)
            .Where(t => t.Name != c.Name && t.Name != "DbGeography")
            .Distinct();
        return string.Join(Environment.NewLine, types.Select(t => $"import {{ {t.Name} }} from '@/models/{t.Name}';").Distinct());
    }
    string NameApi(Class c)
    {
        return c.Name.Replace("Dto", "") + "Api";
    }
    string NameReplaceDto(Class c)
    {
        return c.Name.Replace("Dto", "");
    }
}
$Classes(Annotation.Models.DTOs.*)[
<template>
    <v-flex xs12>
        <v-breadcrumbs divider="/" class="pa-0">
            <v-icon slot="divider">chevron_right</v-icon>
            <v-breadcrumbs-item>
                <v-btn flat class="ma-0" @click="$router.go(-1)" small><v-icon>arrow_back</v-icon> Quay lại</v-btn>
            </v-breadcrumbs-item>
            <v-breadcrumbs-item to="/duan" exact>Dự án</v-breadcrumbs-item>
        </v-breadcrumbs>
        <v-card>
            <v-card-text>
                <v-layout row wrap>
                    <v-flex xs12 sm6 md3>
                        <v-text-field label="Tìm kiếm" placeholder="Tìm kiếm" v-model="searchParamsDuAn.q" @input="getDataFromApi" single-line hide-details></v-text-field>
                    </v-flex>
                    <v-spacer></v-spacer>
                    <v-btn color="primary" small class="mt-4" @click="showModalTaoDuAn">Thêm dự án</v-btn>
                    <v-flex xs12>
                        <v-data-table :headers="tableHeader"
                                      :items="dsDuAn"
                                      @update:pagination="getDataFromApi"
                                      :pagination.sync="searchParamsDuAn"
                                      :total-items="searchParamsDuAn.totalItems"
                                      :loading="loadingTable"
                                      class="table-border table">
                            <template slot="items" slot-scope="props">
                                <td>
                                    {{ props.item.TenDuAn }}
                                </td>
                                <td class="text-xs-center">{{ props.item.MoTa }}</td>
                                <td class="text-xs-center">{{ props.item.SoLuongAnh }}</td>
                                <td class="text-xs-center" style="width:80px;">
                                    <v-tooltip bottom>
                                        <template v-slot:activator="{ on }">
                                            <v-btn flat icon small v-on="on" :to="'/duan/' + props.item.DuAnId" class="ma-0">
                                                <v-icon small>edit</v-icon>
                                            </v-btn>
                                        </template>
                                        <span>Thông tin dự án</span>
                                    </v-tooltip>
                                </td>
                            </template>
                        </v-data-table>
                    </v-flex>
                </v-layout>
            </v-card-text>
        </v-card>
        <v-dialog v-model="dialogConfirmDelete" max-width="290">
            <v-card>
                <v-card-title class="headline">Xác nhận xóa</v-card-title>
                <v-card-text class="pt-3">Bạn có chắc chắn muốn xóa?</v-card-text>
                <v-card-actions>
                    <v-spacer></v-spacer>
                    <v-btn @click.native="dialogConfirmDelete=false" flat>Hủy</v-btn>
                    <v-btn color="red darken-1" @click.native="deleteDuAn" flat>Xác Nhận</v-btn>
                </v-card-actions>
            </v-card>
        </v-dialog>
        <modal-tao-du-an ref="modalTaoDuAn" />
    </v-flex>
</template>
<script lang="ts">
    import { Vue } from 'vue-property-decorator';
    import $NameApi, { $NameApiSearchParams } from '@/apiResources/$NameApi';
    import ModalTao$NameReplaceDto from './ModalTao$NameReplaceDto.vue';
    $ImportsList

    export default Vue.extend({
        components: { ModalTao$NameReplaceDto },
        data() {
            return {
                ds$Name: [] as $Name[],
                tableHeader: [
                    { text: 'Tên dự án', value: 'TenDuAn', align: 'center', sortable: false },
                    { text: 'Mô tả', value: 'MoTa', align: 'center', sortable: false },
                    { text: 'Số lượng ảnh', value: 'SoLuongAnh', align: 'center', sortable: false },
                    { text: 'Thao tác', value: '#', align: 'center', sortable: false },
                ],
                searchParams$NameReplaceDto: { includeEntities: true, rowsPerPage: 25, descending: true, sortBy: '' } as $"{$NameReplaceDto}"ApiSearchParams,
                loadingTable: false,
                selected$Name: {} as $Name,
                dialogConfirmDelete: false,
                items: ["Open", "Doing", "Done", "Reviewing", "Rejected", "Acepted"]
            }
        },
        watch: {
        },
        created() {
        },
        methods: {
            getDataFromApi(pagination: $NameReplaceDto$ApiSearchParams): void {
                 this.loadingTable = true;
                 $NameApi.search(pagination).then(res => {
                     this.ds$Name = res.Data;
                     this.searchParams$NameReplaceDto.totalItems = res.Pagination.totalItems
                     this.loadingTable = false;
                 });
            },
            confirmDelete($name: $Name): void {
                this.selected$Name = $name;
                this.dialogConfirmDelete = true;
            },
            deleteDuAn(): void {
                $NameApi.delete(this.selected$Name.$"{}"Id).then(res => {
                    this.$snotify.success('Xóa thành công!');
                    this.getDataFromApi(this.searchParams$NameReplaceDto);
                    this.dialogConfirmDelete = false;
                }).catch(res => {
                    this.$snotify.error('Xóa thất bại!');
                });
            },
            showModalTao$NameReplaceDto() {
                (this.$refs.modalTao$NameReplaceDto as any).show();
            }
        }
    });
</script>
]