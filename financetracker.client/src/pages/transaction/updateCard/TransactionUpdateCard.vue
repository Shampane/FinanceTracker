<template>
  <div class="theme--orange">
    <h1>Update Transaction</h1>
    <div class="grid_fields">
      <UpdateField title="Id" v-model="updateId" />
      <UpdateField title="Name" v-model="nameField" />
      <UpdateField title="Category" v-model="categoryField" />
      <UpdateField title="Description" v-model="descriptionField" />
      <UpdateField title="Price" v-model="priceField" />
      <UpdateField title="Year" v-model="yearField" />
      <UpdateField title="Month" v-model="monthField" />
      <UpdateField title="Day" v-model="dayField" />
    </div>
    <button type="button" class="button" @click="handleClick">
      Request to update
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
import { Ref, ref } from 'vue';
import UpdateField from './components/TransactionUpdateField.vue';
import { UpdateTransaction } from './services/updateTransaction';
import { IRequestTransactionEntity } from '../../../types/IRequestTransactionEntity';
import { buildRequestTransactionEntity } from '../../../services/buildRequestTransactionEntity';

type IResponseMessage =
  | ''
  | 'The entity was updated!'
  | "Exception: the entity wasn't updated";

const updateId: Ref<string> = ref('');
const nameField: Ref<string> = ref('');
const categoryField: Ref<string> = ref('');
const descriptionField: Ref<string> = ref('');
const priceField: Ref<number | undefined> = ref();
const yearField: Ref<number | undefined> = ref();
const monthField: Ref<number | undefined> = ref();
const dayField: Ref<number | undefined> = ref();

const requestUrl: Ref<string> = ref('http://localhost:8080/Transactions');
const requestClass = new UpdateTransaction();

const responseStatus: Ref<boolean> = ref(false);
const responseMessage: Ref<IResponseMessage> = ref('');

const handleClick = async () => {
  requestUrl.value = `http://localhost:8080/Transactions?Id=${updateId.value}`;
  try {
    if (Number(priceField.value) <= 0) {
      throw new Error('Price must be bigger than 0');
    }

    const newTransaction: IRequestTransactionEntity =
      buildRequestTransactionEntity(
        nameField.value,
        categoryField.value,
        descriptionField.value,
        Number(priceField.value),
        Number(yearField.value),
        Number(monthField.value),
        Number(dayField.value),
      );
    console.log(newTransaction);

    await requestClass.update(requestUrl.value, newTransaction);
    responseStatus.value = true;
    responseMessage.value = 'The entity was updated!';
  } catch {
    responseStatus.value = false;
    responseMessage.value = "Exception: the entity wasn't updated";
  }
  requestUrl.value = `http://localhost:8080/Transactions`;
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
