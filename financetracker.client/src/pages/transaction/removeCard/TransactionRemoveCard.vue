<template>
  <div>
    <h1>Remove Transaction</h1>
    <h2>Delete By Id</h2>
    <input
      type="text"
      v-model="removeId"
      placeholder="Write Id to remove..."
      class="input-text"
    />
    <button type="button" class="button" @click="handleClick">
      Request to remove
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
import { RemoveTransactions } from './services/removeTransactions';

type IResponseMessage =
  | ''
  | 'The entity was removed!'
  | "Exception: the entity wasn't removed";

const requestUrl: Ref<string> = ref('http://localhost:8080/Transactions');
const requestClass = new RemoveTransactions();
const removeId: Ref<string> = ref('');

const responseStatus: Ref<boolean> = ref(false);
const responseMessage: Ref<IResponseMessage> = ref('');

const handleClick = async () => {
  requestUrl.value = `http://localhost:8080/Transactions?Id=${removeId.value}`;
  try {
    await requestClass.remove(requestUrl.value);
    responseStatus.value = true;
    responseMessage.value = 'The entity was removed!';
  } catch {
    responseStatus.value = false;
    responseMessage.value = "Exception: the entity wasn't removed";
  }
};
</script>

<style scoped>
.button {
  margin-top: 1vh;
}

.input-text {
  min-width: 21em;
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
