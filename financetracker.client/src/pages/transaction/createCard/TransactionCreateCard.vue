<template>
  <div>
    <h1>Create Transaction</h1>
    <div class="grid_fields">
      <CreateField title="Name" v-model="nameField" />
      <CreateField title="Category" v-model="categoryField" />
      <CreateField title="Description" v-model="descriptionField" />
      <CreateField title="Price" v-model="priceField" />
      <CreateField title="Year" v-model="yearField" />
      <CreateField title="Month" v-model="monthField" />
      <CreateField title="Day" v-model="dayField" />
    </div>
    <button type="button" class="button" @click="handleClick">
      Request to create
    </button>
    <p
      :class="[
        responseStatus ? `message message--success` : `message message--error`,
      ]"
    >
      {{ responseMessage }}
    </p>
  </div>
</template>

<script setup lang="ts">
import { ref, Ref } from 'vue';
import CreateField from './components/TransactionCreateField.vue';
import { ICreateTransactionEntity } from '../../../types/ICreateTransactionEntity';
import { buildCreateTransactionEntity } from './services/buildCreateTransactionEntity';
import { CreateTransactions } from './services/createTransaction';

type IResponseMessage =
  | ''
  | 'The entity was created!'
  | "Exception: the entity wasn't created";

const nameField: Ref<string> = ref('');
const categoryField: Ref<string> = ref('');
const descriptionField: Ref<string> = ref('');
const priceField: Ref<number | undefined> = ref();
const yearField: Ref<number | undefined> = ref();
const monthField: Ref<number | undefined> = ref();
const dayField: Ref<number | undefined> = ref();

const responseStatus: Ref<boolean> = ref(false);
const responseMessage: Ref<IResponseMessage> = ref('');

const requestClass = new CreateTransactions();

const handleClick = async () => {
  const url: string = 'http://localhost:8080/Transactions';

  try {
    if (Number(priceField.value) <= 0) {
      throw new Error('Price must be bigger than 0');
    }

    const newTransaction: ICreateTransactionEntity =
      buildCreateTransactionEntity(
        nameField.value,
        categoryField.value,
        descriptionField.value,
        Number(priceField.value),
        Number(yearField.value),
        Number(monthField.value),
        Number(dayField.value),
      );
    console.log(newTransaction);

    await requestClass.create(url, newTransaction);
    responseStatus.value = true;
    responseMessage.value = 'The entity was created!';
  } catch {
    responseStatus.value = false;
    responseMessage.value = "Exception: the entity wasn't created";
  }
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

.message {
  margin-top: calc(1vh + 16px);
  font-size: 1.5em;
  font-weight: 700;
}

.message--success {
  color: var(--green-color);
}

.message--error {
  color: var(--red-color);
}
</style>
