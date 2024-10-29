import axios from 'axios';

export class RemoveTransactions {
  public remove = async (url: string): Promise<void> => await axios.delete(url);
}
