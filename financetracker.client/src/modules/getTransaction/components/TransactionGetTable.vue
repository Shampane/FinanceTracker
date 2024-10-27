<template>
  <table v-if="list.length > 0" class="table">
    <thead>
      <tr>
        <th v-for="(header, index) in tableHeaders" :key="index">
          {{ header }}
        </th>
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

<script setup lang="ts">
import { ITransactionEntity } from '../types/ITransactionEntity';

interface Props {
  list: ITransactionEntity[];
}

const props = defineProps<Props>();

const tableHeaders: string[] = [
  '№',
  'Id',
  'Name',
  'Category',
  'Description',
  'Price',
  'Date',
];
</script>

<style scoped>
.table {
  margin: 1vh 0;
}
</style>
