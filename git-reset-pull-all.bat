echo "git reset pull all"
Pause
git reset --hard
git checkout master
git pull
git submodule foreach --recursive git reset --hard
git submodule foreach --recursive git checkout master
git submodule foreach --recursive git pull
echo "complete"
Pause
