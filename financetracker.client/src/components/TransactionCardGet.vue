<template>
  <h1>Get Transactions</h1>
  <div class="flex-full">
    <input
      type="text"
      v-model="idToSearch"
      placeholder="Write Id to search..."
    />
  </div>

  <button type="button" @click="handleClick" class="button">
    Click to Get
  </button>
  <table v-if="list?.length > 0" class="table">
    <thead>
      <tr>
        <th v-for="(item, index) in tableHeaders" :key="index">{{ item }}</th>
      </tr>
    </thead>

    <tbody>
      <tr v-for="(item, index) in list" :key="item.id">
        <td style="text-align: center">{{ index + 1 }}</td>
        <td>{{ item.id }}</td>
        <td>{{ item.name }}</td>
        <td>{{ item.category }}</td>
        <td>{{ item.description }}</td>
        <td>{{ item.price }}</td>
        <td>{{ item.transactionDate }}</td>
      </tr>
    </tbody>
  </table>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import {
  GetTransactionById,
  GetTransactions,
} from '../services/InteractionTransactionsApi';
import { ITransactionEntity } from '../types/ITransaction';

export default defineComponent({
  data() {
    return {
      getUrl: 'http://localhost:8080/Transactions' as string,
      idToSearch: '' as string,
      list: [] as ITransactionEntity[],
      tableHeaders: [
        '№',
        'Id',
        'Name',
        'Category',
        'Description',
        'Price',
        'Date',
      ],
    };
  },
  methods: {
    async handleClick() {
      this.getUrl = 'http://localhost:8080/Transactions';
      if (this.idToSearch != '' && !this.getUrl.toLowerCase().includes('id')) {
        this.getUrl += `?Id=${this.idToSearch}`;
        try {
          this.list = Array(1).fill(await GetTransactionById(this.getUrl));
        } catch {
          this.list = [];
        }
      } else {
        this.list = await GetTransactions(this.getUrl);
      }
    },
  },
});
</script>

<style scoped>
.button {
  margin-top: 2vh;
}

.table {
  margin: 1vh 0;
}

.flex-full {
  margin-top: 1.2vh;
  display: flex;
  column-gap: 1vw;
}

.flex-full > * {
  width: 100%;
}
</style>
