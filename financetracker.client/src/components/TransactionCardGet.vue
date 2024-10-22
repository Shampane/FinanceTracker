<template>
  <h1>Get Transactions</h1>
  <button type="button" @click="handleClick">Click to Get</button>
  <div>{{ list }}</div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import { GetTransactions } from '../services/InteractionTransactionsApi';
import { ITransactionEntity } from '../types/ITransaction';

export default defineComponent({
  data() {
    return {
      list: [] as ITransactionEntity[],
    };
  },
  methods: {
    async handleClick() {
      this.list = await GetTransactions();
    },
  },
});
</script>

<style scoped></style>
