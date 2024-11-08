<template>
  <div class="theme--blue">
    <h1>Get Transactions</h1>
    <div class="grid_fields">
      <SearchField title="Id" v-model="searchId" />
      <SearchField title="Name" v-model="searchName" />
      <SearchField title="Category" v-model="searchCategory" />
      <PaginationField title="Pagination Size" v-model="paginationSize" />
      <PaginationField title="Pagination Page" v-model="paginationPage" />

      <SortField
        title="Sort Type"
        :options="sortTypeOptions"
        v-model="sortType"
      />
      <SortField
        title="Sort Order"
        :options="sortOrderOptions"
        v-model="sortOrder"
      />
    </div>

    <button type="button" @click="handleClick" class="button">
      Request to get
    </button>

    <Table :list="responseList" />
  </div>
</template>

<script setup lang="ts">
import { ref, type Ref } from "vue";
import SearchField from "./components/TransactionGetSearchField.vue";
import PaginationField from "./components/TransactionGetPaginationField.vue";
import SortField from "./components/TransactionGetSortField.vue";
import Table from "./components/TransactionGetTable.vue";

import { buildGetRequestUrl } from "./services/buildGetRequestUrl";
import { GetTransactions } from "./services/getTransactions";
import { ITransactionEntity } from "../../../types/ITransactionEntity";

const searchId: Ref<string> = ref("");
const searchName: Ref<string> = ref("");
const searchCategory: Ref<string> = ref("");
const sortType: Ref<string> = ref("");
const sortOrder: Ref<string> = ref("");
const paginationSize: Ref<number> = ref(0);
const paginationPage: Ref<number> = ref(0);

const requestUrl: Ref<string> = ref("http://localhost:8080/Transactions");
const responseList: Ref<ITransactionEntity[]> = ref([]);
const requestClass = new GetTransactions();

const sortTypeOptions: string[] = ["Category", "Price", "Date"];
const sortOrderOptions: string[] = ["ASC", "DESC"];

const handleClick = async () => {
  requestUrl.value = buildGetRequestUrl(
    "http://localhost:8080/Transactions",
    searchId.value,
    searchName.value,
    searchCategory.value,
    sortType.value,
    sortOrder.value,
    paginationSize.value,
    paginationPage.value
  );
  if (requestUrl.value.includes("Id")) {
    try {
      responseList.value = Array(1).fill(
        await requestClass.getById(requestUrl.value)
      );
    } catch {
      responseList.value = [];
    }
  } else {
    responseList.value = await requestClass.get(requestUrl.value);
  }
  requestUrl.value = "http://localhost:8080/Transactions";
};
</script>

<style scoped>
.grid_fields {
  margin-top: 1.2vh;
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(300px, 1fr));

  column-gap: 1vw;
  row-gap: calc(1vh + 4px);
}

.button {
  margin-top: 1vh;
}
</style>
