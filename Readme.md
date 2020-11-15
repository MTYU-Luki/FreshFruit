﻿# Currency Apps
Aplikasi sperti kranjang buah yang di mana jika sudah penuh kranjangnya akan ada 
peringatan kranjang penuh

## Scope & Functionalities
- Dapat menambahkan Buah ke kranjang sesui kapasitas
- Dapat meghapus buah yang sudah di masukan

# Tugas

## Jawaban No 1
Jika buah yang di masukan ke kranjang berhasil maka akan ada pesan "Yey, berhasil ditambahkan" , 
Tapi jika buah yang dimasukan ke Kranjang sudah Penuh maka akn muncul pesan "Ops, keranjang penuh"

## Jawaban No 2
![Class Diagram](https://github.com/MTYU-Luki/FreshFruit/blob/master/FreshFruit/ClassDiagram1.png)

## Jawaban No 3
diawali pada `MainWindow.xaml.cs`

```csharp

public MainWindow()
        {
            InitializeComponent();

            Bucket KeranjangBuah = new Bucket(4); // menset berapa jumlah maksimal buah yang bisa dimasukan ke kranjang
            BucketController bucketController = new BucketController(KeranjangBuah, this);

            Luki = new Seller("Luki", bucketController);
            ListBoxBucket.ItemsSource = KeranjangBuah.findAll();
        }
```

kemudian pada `Bucket.cs` terdapat beberapa fungis seperti ,insert, remove, findall, getcapacity, count item.

```csharp
        public void insert(Fruit fruit)
        {
            this.fruits.Add(fruit);
        }
        public void remove(int position)
        {
            this.fruits.RemoveAt(position);
        }
        public List<Fruit> findAll()
        {
            return this.fruits;
        }

        public int getCapacity()//men set berapa maksimal item di kranjang
        {
            return this.capacity;
        }
        public int countItems()//meghitung item pada kranjang
        {
            return this.fruits.Count();
        }
```

Kemudian pada `BucketController.cs`, ada 2 fungsi yaitu addFruit yaitu untuk menambahkan bucket ke kranjang , kemudian removeFruit untuk menghapus buah pada kranjnag buah

```csharp
        public void addFruit(Fruit fruit)
        {
            if (bucketIsOverload())
            {
                eventListener.onFailed("Ops, keranjang penuh");
            }
            else
            {
                this.bucket.insert(fruit);
                eventListener.onSucceed("Yey, berhasil ditambahkan");
            }
        }

        public void removeFruit(Fruit fruit)
        {
            for (int itemPosition = 0; itemPosition < bucket.countItems(); itemPosition++)
            {
                if (bucket.findAll().ElementAt(itemPosition).getName() == fruit.name)
                {
                    bucket.remove(itemPosition);
                    eventListener.onSucceed("Yeay, Berhasil dihapus");
                }
            }
        }
```