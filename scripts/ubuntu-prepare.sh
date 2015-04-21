wget http://dist.libuv.org/dist/v1.0.0-rc2/libuv-v1.0.0-rc2.tar.gz
tar -xvf libuv-v1.0.0-rc2.tar.gz
cd libuv-v1.0.0-rc2
mkdir -p build
git clone https://chromium.googlesource.com/external/gyp build/gyp
./gyp_uv.py -f make -Duv_library=shared_library
make -C out
sudo cp out/Debug/lib.target/libuv.so /usr/lib/libuv.so.1.0.0-rc2
sudo ln -s libuv.so.1.0.0-rc2 /usr/lib/libuv.so.1
cd ..
rm ./libuv-v1.0.0-rc2.tar.gz
rm -rf libuv-v1.0.0-rc2
