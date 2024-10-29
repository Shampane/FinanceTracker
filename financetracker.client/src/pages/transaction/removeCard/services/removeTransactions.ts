import axios from 'axios';

export class RemoveTransaction {
  public remove = async (url: string): Promise<void> => await axios.delete(url);
}
