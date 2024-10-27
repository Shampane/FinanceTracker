<template>
  <h1>Get Transactions</h1>
  <div class="grid_fields">
    <SearchField title="Id" v-model="searchId" />
    <SearchField title="Name" v-model="searchName" />
    <SearchField title="Category" v-model="searchCategory" />
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
</template>

<script setup lang="ts">
import { ref, type Ref } from 'vue';
import SearchField from '../components/TransactionGetSearchField.vue';
import SortField from '../components/TransactionGetSortField.vue';
import Table from '../components/TransactionGetTable.vue';

import { buildGetResponseUrl } from '../services/buildGetResponseUrl';
import { GetTransactions } from '../services/GetTransactions';
import { ITransactionEntity } from '../types/ITransactionEntity';

const searchId: Ref<string> = ref('');
const searchName: Ref<string> = ref('');
const searchCategory: Ref<string> = ref('');
const sortType: Ref<string> = ref('');
const sortOrder: Ref<string> = ref('');

const responseUrl: Ref<string> = ref('http://localhost:8080/Transactions');
const responseList: Ref<ITransactionEntity[]> = ref([]);
const responseClass = new GetTransactions();

const sortTypeOptions: string[] = ['Category', 'Price', 'Date'];
const sortOrderOptions: string[] = ['ASC', 'DESC'];

const handleClick = async () => {
  responseUrl.value = buildGetResponseUrl(
    'http://localhost:8080/Transactions',
    searchId.value,
    searchName.value,
    searchCategory.value,
    sortType.value,
    sortOrder.value,
  );
  if (responseUrl.value.includes('Id')) {
    try {
      responseList.value = Array(1).fill(
        await responseClass.getById(responseUrl.value),
      );
    } catch {
      responseList.value = [];
    }
  } else {
    responseList.value = await responseClass.get(responseUrl.value);
  }
  responseUrl.value = 'http://localhost:8080/Transactions';
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
  font-size: 1.1em;
  font-weight: 700;
}
</style>
